import React from 'react';
import {useStripe, useElements, CardElement} from '@stripe/react-stripe-js';
import CardSection from './cardSection';

export default function CardSetupForm() {
  const stripe = useStripe();
  const elements = useElements();

  const [clientSecret, setClientSecret] = React.useState();

  React.useEffect(()=>{
    fetch("https://localhost:44387/api/User/GetStripeClientSecret")
    .then(res=>res.json())
    .then((response)=>{
        setClientSecret(response.data);
    })
    .catch(()=>{});
  },[setClientSecret]);

  const handleSubmit = async (event) => {
    // We don't want to let default form submission happen here,
    // which would refresh the page.
    event.preventDefault();

    if (!stripe || !elements) {
      // Stripe.js has not yet loaded.
      // Make sure to disable form submission until Stripe.js has loaded.
      return;
    }
    
    const result = await stripe.confirmCardSetup(clientSecret, {
      payment_method: {
        card: elements.getElement(CardElement),
        billing_details: {
          name: 'Jenny Rosen',
        },
      }
    });

    if (result.error) {
        console.log("Error", result.error);
      // Display result.error.message in your UI.
    } else {
        console.log("Setup complete", result.setupIntent.payment_method);
        const requestOptions = {
            method: 'POST'
        };
        var url = new URL("https://localhost:44387/api/User/AddPaymentMethod");
        var params = { paymentMethodId: result.setupIntent.payment_method };
        url.search = new URLSearchParams(params).toString();
        fetch(url, requestOptions)
            .then(response => response.json());
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <CardSection />
      <button disabled={!stripe}>Save Card</button>
    </form>
  );
}