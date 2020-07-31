import React, { useState } from 'react'
import { allCharacterPortrait } from '../components/allCharacterPortrait'

export function Notes() {
  return (
    <div className="notes">
      <section className="header">
        <header>
          <h2>Welcome to Smash Combos</h2>
          <div className="error-message">
            <i class="fas fa-exclamation-triangle"></i>
            <p className="red-text">
              This a beta version with a limited data storage plan. When the app
              is ready for a full release, all combos saved here will be
              deleted. More information coming soon.
            </p>
          </div>
          <img src="https://media.giphy.com/media/AFpghpBCYEAwM/giphy.gif" />
          <p>
            Hi thanks for checking this app out! This app was created as my
            final project for Suncoast Developers Guild, a coding bootcamp in
            St.Petersburg FL.
          </p>
          <p>
            My hopes for this app is to make the process of learning a new
            character in Smash Bros Ultimate an enjoyable experience by easily
            having combos accessible with the help of the community.
          </p>
          <p>
            Any feedback is greatly appreciated as this app is a working
            progress. I hope this app will help you in the journey of learning a
            new character :)
          </p>
          <p>Love,</p> <p>Kento</p>
        </header>
      </section>
      <section>
        <h3>Latest Patch Notes:</h3>
        <ul>
          <li>
            <h4>July 29, 2020</h4>
            <p>
              Debut time! The beta version of Smash Combos is officially live :)
            </p>
            <p>
              I will be doing a short little presentation and demo at{' '}
              <a href="https://suncoast.io/conference">
                Suncoast Developers Guild Conference
              </a>{' '}
              at 11:00AM EST Please feel free to RSVP and join us for the online
              conference where I will be talking about the app!
            </p>
          </li>
        </ul>
      </section>

      <section>
        <h3>Known Issues</h3>
        <ul>
          <li>Duplicate Display Names</li>
        </ul>
      </section>

      <section>
        <h3>Features on the way</h3>
        <ul>
          <li>
            <p>Google/Facebook Authentication</p>
          </li>
          <li>
            <p>Character Matchups</p>
          </li>
          <li>
            <p>User Profile</p>
          </li>
        </ul>
      </section>

      <section>
        <h3>Reporting Issues</h3>
        <p>
          Please report any known issues on the{' '}
          <a href="https://github.com/Breadkenty/Smash_Combos">
            Github repository
          </a>{' '}
          issues as well as suggesting feedback.
        </p>
      </section>

      <section>
        <h3>Supporting the project</h3>
        <p>Coming soon...</p>
      </section>

      <section>
        <h3>Technologies</h3>

        <h4>Front end</h4>
        <ul>
          <li>
            <p>React.js</p>
          </li>
          <li>
            <p>Youtube API</p>
          </li>
        </ul>

        <h4>Backend</h4>
        <ul>
          <li>
            <p>C# / .NET</p>
          </li>
          <li>
            <p>Entity Framework</p>
          </li>
          <li>
            <p>PostgreSQL Database</p>
          </li>
        </ul>

        <h4>Host</h4>
        <ul>
          <li>
            <p>Heroku</p>
          </li>
        </ul>

        <h4>Source Code</h4>
        <ul>
          <li>
            <a href="https://github.com/Breadkenty/Smash_Combos">Github</a>
          </li>
        </ul>
      </section>

      <section>
        <h3>Credits:</h3>
        <ul>
          <li>
            <a href="https://www.ssbwiki.com/">
              Smash Wiki <span>: Controller buttons</span>
            </a>
          </li>
          <li>
            <a href="https://www.spriters-resource.com/">
              Spriters Resource<span>: Character images</span>
            </a>
          </li>
          <li>
            <a href="https://twitter.com/Samsora_">
              eU Samsora
              <span>: Videos for examples, and bc I'm also a Peach main</span>
            </a>
          </li>
          <li>
            <a href="https://suncoast.io/">
              Suncoast Developers Guild
              <span>
                : Where I learned to make this app in 3 months from no
                experience whatsoever
              </span>
            </a>
          </li>
        </ul>
      </section>
    </div>
  )
}
