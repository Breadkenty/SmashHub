# Contributing to Smash Combos

---

Yay! Thank you for being interested in contributing! 🎈

This document will explain how you can contribute by getting you started with environment setups, contributing guides, syling guides and more.

## Code of Conduct

Please be sure to follow our <a href="./CODE_OF_CONDUCT.md">Code of conduct</a> as we strive to create a positive and welcoming environment.

## Asking a Question

Please bring all of your questions to our <a href="https://discord.com/invite/VbnAwUg">Discord server</a> as this will be the fastest, and most efficient way in getting hold of me. Please introduce yourself as a developer/contributor so we can grant you access to our development channel.

## How to get started

There are a few tools you need to get started...
**If you are on a Mac** and have <a href="https://brew.sh/">Homebrew</a> installed we've put together quick commands to get you set up quickly.

1. **npm**
   `brew install nodejs`
   `npm install --global rimraf`

2. **dotnet**
   `brew cask install dotnet-sdk`
   `dotnet tool install --global dotnet-ef`
   `dotnet tool install --global dotnet-aspnet-codegenerator`

3. **PostgreSQL**
   `brew install postgresql`
   `brew services start postgresql`

4. **Development environment**
   `echo "export ASPNETCORE_ENVIRONMENT=Development" >> ~/.zshrc`
   `echo "export ASPNETCORE_ENVIRONMENT=Development" >> ~/.bash_profile`
   `dotnet dev-certs https --trust`

**If you are on PC** and have <a href="https://scoop.sh/">Scoop</a> installed, we've put together quick commands to get you set up quickly.

1. **npm**
   `scoop install nodejs`
   `npm install --global windows-build-tools`
   `npm install --global rimraf`

2. **dotnet**
   `scoop install dotnet-sdk`
   `dotnet tool install --global dotnet-ef`
   `dotnet tool install --global dotnet-aspnet-codegenerator`

3. **PostgreSQL**
   `scoop install postgresql`

4. **Development environment**
   `setx ASPNETCORE_ENVIRONMENT Development`
   `dotnet dev-certs https --trust`

#### Preparing the database and .NET to do local development

After you've installed everything above, you need to do a couple of things to ensure your local development works properly.

1. **In the root folder of `Smash_Combos` run:**
   `dotnet restore`

2. **Update the database with the existing migrations**
   `dotnet ef database update`

3. **Import the characters into your local database**
   `psql Smash_ComboDatabase --file=Models/characters.sql`

4. **Remove the `node_modules` file in the `ClientApp` folder**
   If you have <a href="https://www.npmjs.com/package/trash">Trash</a> installed, you can do `trash node_modules`

5. **Install npm in `ClientApp`**
   `cd ClientApp`
   `npm install`

6. **Set a JWT token locally for login sessions to work. Set the token on the root folder of `Smash_Combos`**
   You can just choose any set of strings but you can also grab a random key here: https://www.grc.com/passwords.htm
   `../` or `cd ..`
   `dotnet user-secrets set "JWT_KEY" "PASTE SOME STRING HERE"`

7. **Run the app locally and get started!**
   Everytime you want to launch your changes live, run the command `dotnet watch run`.
   On your browser and go to `https://0.0.0.0:5001`, and you should have the app running locally!

## How can you contribute?

#### Bugs

Please report all bugs as issues with the `bugs` label. Here are some things to consider when submitting an issue:

1. **Your title should describe the problem in one sentence**. It should concise and straight to the point.
1. **Describe the exact steps taken to replicate the issue**. You should include details such as where the bug occurs, what does it prevent you from doing, any conditions, etc.
1. **Explain what it should do**. The bug will usually prevent you from doing something, therefore state what the feature should do.
1. **Include screenshots or gifs if applicable**. Images/videos are great ways to visualize what you are seeing. Please include them if possible.
1. **To reiterate, please be specific**. Being as detailed and specific makes issues easier to understand. The goal here is to replicate exactly what you are seeing. If we are not able to replicate the issue then it's harder to identify the bug.

#### Features and enhancements

The goal for Smash Combos is to provide a platform for players in Super Smash Bros (Ultimate) to share competitive information with one another. Which means we will be doing our best to listen to the community and their needs. Most feature requests will happen on our <a href="https://discord.com/invite/VbnAwUg">Discord server</a> however they will ultimately be posted as issues. Please tag the issues with the `enhancements` label.

1. **Like bugs, have a clear descriptive title that can be explained in one sentence**. When requesting a feature, they should be broken down into small manageable bite-size pieces.
2. **Describe what the feature does, and why it should be included**. It's important to know why the feature is being added in the first place. Features requests will be decided depending on the demand by the users.
3. **Attach images or visual explanations on how the feature should be implemented**. This will give us a better idea on how we would like to create the UI that is friendly to the user experience.
4. **Provide some examples to how this feature would look**. Examples, like images should give us a better idea to understand why it should be included.

#### Styleguide

##### Commits

Your commits should use past tense (eg. "Created a new variable" and not "Creates a new variable").
Consider using emojis to better understand the type of commits you make:

💜 `:purple_heart:` when improving the format/structure of the code

🐎 `:racehorse:` when improving performance

📝 `:memo:` when writing docs

🦟 `:ant:` when fixing a bug

🔥 `:fire:` when removing code or files

🎨 `:art:` when dealing with styling

💾 `:floppy_disk:` when dealing with backend

📦 `:package:` when preparing files

##### HTML/CSS

Snakecase: `class-names, should-be, snake-cased`

##### Javascript

Camelcase `variableNames, shouldBe, camelCased`

##### Csharp

Camelcase `variableNames, shouldBe, camelCased`

---

This wraps up everything you need to know before getting started. Please keep in mind that this document is a work in progress and is bound to change. Keep checking in to make sure you are receiving the latest information. Thank you again for your time and we look forward to your contributions! Happy coding 💻

Kento
