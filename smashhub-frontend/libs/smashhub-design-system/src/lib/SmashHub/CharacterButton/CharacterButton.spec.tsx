import { render } from '@testing-library/react';

import CharacterButton from './CharacterButton';

describe('CharacterButton', () => {
  it('should render successfully', () => {
    const { container } = render(<CharacterButton variableName="ZeroSuitSamus"/>);
    expect(container.getElementsByTagName('div')[0].style.backgroundImage).toEqual('url(https://res.cloudinary.com/dtojhch6o/image/upload/v1623536225/SmashHub/character-emblem/ZeroSuitSamus-emblem.png)')
  });
});
