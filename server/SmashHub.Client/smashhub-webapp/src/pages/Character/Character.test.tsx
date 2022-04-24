import React from "react";
import { render, screen } from "@testing-library/react";
import Character from "./Character";

test("renders Character", () => {
  render(<Character />);
  const element = screen.getByText(/Character/i);
  expect(element).toBeInTheDocument();
});
