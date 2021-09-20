import { render } from '@testing-library/react';

import SmashhubDesignSystem from './SmashhubDesignSystem';

describe('SmashhubDesignSystem', () => {
  it('should render successfully', () => {
    const { baseElement } = render(<SmashhubDesignSystem />);
    expect(baseElement).toBeTruthy();
  });
});
