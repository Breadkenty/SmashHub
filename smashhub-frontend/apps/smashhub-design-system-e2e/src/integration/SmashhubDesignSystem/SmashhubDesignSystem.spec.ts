describe('smashhub-design-system: SmashhubDesignSystem component', () => {
  beforeEach(() => cy.visit('/iframe.html?id=smashhubdesignsystem--primary'));
    
    it('should render the component', () => {
      cy.get('h1').should('contain', 'Welcome to SmashhubDesignSystem!');
    });
});
