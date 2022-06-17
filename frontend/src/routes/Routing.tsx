import { BrowserRouter, Routes, Route } from "react-router-dom";
import { LandingPage } from "../view/landingPage/LandingPage";

export const Routing = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<LandingPage />} />
      </Routes>
    </BrowserRouter>
  );
};
