import React from "react";
import { render, screen } from "@testing-library/react";
import Reports from "./Reports";

test("renders Reports", () => {
  render(<Reports />);
  const element = screen.getByText(/Reports/i);
  expect(element).toBeInTheDocument();
});
