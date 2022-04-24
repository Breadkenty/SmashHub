import React from "react";
import { render, screen } from "@testing-library/react";
import SignUp from "./SignUp";

test("renders SignUp", () => {
  render(<SignUp />);
  const element = screen.getByText(/SignUp/i);
  expect(element).toBeInTheDocument();
});
