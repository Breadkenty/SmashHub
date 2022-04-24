import React from "react";
import { render, screen } from "@testing-library/react";
import Faq from "./Faq";

test("renders Faq", () => {
  render(<Faq />);
  const element = screen.getByText(/Faq/i);
  expect(element).toBeInTheDocument();
});
