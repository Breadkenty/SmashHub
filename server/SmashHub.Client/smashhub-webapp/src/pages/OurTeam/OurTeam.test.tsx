import React from "react";
import { render, screen } from "@testing-library/react";
import OurTeam from "./OurTeam";

test("renders OurTeam", () => {
  render(<OurTeam />);
  const element = screen.getByText(/OurTeam/i);
  expect(element).toBeInTheDocument();
});
