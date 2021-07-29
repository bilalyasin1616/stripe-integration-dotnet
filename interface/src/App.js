import './App.css';
import {Elements} from '@stripe/react-stripe-js';
import {loadStripe} from '@stripe/stripe-js';
import CardSetupForm from './stripe/cardSetupForm';

const stripePromise = loadStripe('pk_test_51JHnhiHmo0pcw98J9RZX2xMEifabA5tW9lWX9xkkHbHEQUAoSfvpDFNrNrgbL2n7guYaeSTbrAigcCYxKVO5e4eB00SRvUOhY5');

function App() {
  return (
    <div className="App">
      <Elements stripe={stripePromise}>
        <CardSetupForm />
      </Elements>
    </div>
  );
}

export default App;
