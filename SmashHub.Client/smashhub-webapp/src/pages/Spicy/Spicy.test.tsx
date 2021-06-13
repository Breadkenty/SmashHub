import React from "react";
import { render, screen } from "@testing-library/react";
import Spicy from "./Spicy";

test("renders Spicy", () => {
  render(<Spicy />);
  const element = screen.getByText(/Spicy/i);
  expect(element).toBeInTheDocument();
});
