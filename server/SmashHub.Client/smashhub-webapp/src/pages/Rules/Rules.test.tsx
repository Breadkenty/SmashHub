import React from "react";
import { render, screen } from "@testing-library/react";
import Rules from "./Rules";

test("renders Rules", () => {
  render(<Rules />);
  const element = screen.getByText(/Rules/i);
  expect(element).toBeInTheDocument();
});
