import React from "react";
import { render, screen } from "@testing-library/react";
import App from "./App";

test("renders learn react link", () => {
  render(<App />);
  const linkElement = screen.getByText(/huh/i);
  expect(linkElement).toBeInTheDocument();
});

test("my test", () => {
  console.log("huh");
});
