import React from "react";
import { render, screen } from "@testing-library/react";
import Submit from "./Submit";

test("renders Submit", () => {
  render(<Submit />);
  const element = screen.getByText(/Submit/i);
  expect(element).toBeInTheDocument();
});
