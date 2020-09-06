import React from 'react'

export function Notes() {
  return (
    <div className="notes">
      <section className="header">
        <header>
          <h2>Welcome to Smash Combos</h2>
          <div className="error-message">
            <i className="fas fa-exclamation-triangle"></i>
            <p className="red-text">
              This a beta version with a limited data storage plan. When the app
              is ready for a full release, all combos saved here will be
              deleted. More information coming soon.
            </p>
          </div>
          <img
            src="https://media.giphy.com/media/AFpghpBCYEAwM/giphy.gif"
            alt="animation of pikachu walking with a ketchup"
          />
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
        <h3>Reporting Issues</h3>
        <p>
          Please report any known issues on the{' '}
          <a href="https://github.com/Breadkenty/Smash_Combos">
            Github repository
          </a>{' '}
          or on our <a href="https://discord.gg/VbnAwUg">Discord Server</a>{' '}
          issues as well as suggesting feedback.
        </p>
      </section>

      <section>
        <h3>Supporting the project</h3>
        <p>Coming soon...</p>
      </section>

      <section>
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
            <a href="https://ultimateframedata.com/">
              Ultimate Frame Data
              <span>: Was really inspired by MetalMusicMan's work!</span>
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
