import React from "react";
import { render, screen } from "@testing-library/react";
import Updates from "./Updates";

test("renders Updates", () => {
  render(<Updates />);
  const element = screen.getByText(/Updates/i);
  expect(element).toBeInTheDocument();
});
