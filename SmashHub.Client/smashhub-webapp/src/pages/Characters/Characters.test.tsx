import React from "react";
import { render, screen } from "@testing-library/react";
import Characters from "./Characters";

test("renders Characters", () => {
  render(<Characters />);
  const element = screen.getByText(/Characters/i);
  expect(element).toBeInTheDocument();
});
