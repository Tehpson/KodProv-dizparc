import ReactDOM from 'react-dom/client';
import './index.css';
import { Routing } from './routes/Routing';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);
root.render(
    <Routing />
);
