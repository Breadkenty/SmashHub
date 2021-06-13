import React from "react";
import { render, screen } from "@testing-library/react";
import User from "./User";

test("renders User", () => {
  render(<User />);
  const element = screen.getByText(/User/i);
  expect(element).toBeInTheDocument();
});
