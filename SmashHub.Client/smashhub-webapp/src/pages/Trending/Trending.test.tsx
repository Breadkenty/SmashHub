import React from "react";
import { render, screen } from "@testing-library/react";
import Trending from "./Trending";

test("renders Trending", () => {
  render(<Trending />);
  const element = screen.getByText(/Trending/i);
  expect(element).toBeInTheDocument();
});
