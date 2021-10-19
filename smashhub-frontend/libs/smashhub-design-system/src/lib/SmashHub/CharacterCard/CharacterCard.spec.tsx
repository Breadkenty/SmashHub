import { render } from '@testing-library/react';

import CharacterCard from './CharacterCard';

describe('CharacterCard', () => {
  it('should render successfully', () => {
    const { getByTestId, getByText } = render(<CharacterCard name="Zero Suit Samus" variableName="ZeroSuitSamus" yPosition={8}/>);

    expect(getByText('Zero Suit Samus')).toBeTruthy()
    expect(getByTestId('character-image').style.backgroundImage).toEqual('url(https://res.cloudinary.com/dtojhch6o/image/upload/v1623536225/SmashHub/character-portrait/ZeroSuitSamus-portrait.png)')
    expect(getByTestId('character-image').style.backgroundPositionY).toEqual('8%')
  });
});
