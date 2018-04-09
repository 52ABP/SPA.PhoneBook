import { PhoneBookTemplatePage } from './app.po';

describe('PhoneBook App', function() {
  let page: PhoneBookTemplatePage;

  beforeEach(() => {
    page = new PhoneBookTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
