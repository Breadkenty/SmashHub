import React from "react";
import { render, screen } from "@testing-library/react";
import Home from "./Home";

test("renders Home", () => {
  render(<Home />);
  const element = screen.getByText(/Home/i);
  expect(element).toBeInTheDocument();
});
