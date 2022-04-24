import React from "react";
import { render, screen } from "@testing-library/react";
import PrivacyPolicy from "./PrivacyPolicy";

test("renders PrivacyPolicy", () => {
  render(<PrivacyPolicy />);
  const element = screen.getByText(/PrivacyPolicy/i);
  expect(element).toBeInTheDocument();
});
