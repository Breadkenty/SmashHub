import React, { useState, useEffect } from 'react'

export function Notes() {
  const [contributors, setContributors] = useState([])

  function getContributors() {
    fetch('https://api.github.com/repos/Breadkenty/Smash_Combos/contributors')
      .then(response => {
        return response.json()
      })
      .then(apiData => {
        setContributors(apiData)
      })
  }

  useEffect(getContributors, [])

  return (
    <div className="notes">
      <section className="header">
        <header>
          <h2>Welcome to Smash Combos</h2>

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
          <br />
          <p>Love,</p>
          <p>Kento</p>
        </header>
      </section>

      <section>
        <h3>Presentation:</h3>
        <a href="https://www.youtube.com/watch?v=fdlWmefqX_s">
          Video Presentation on how this app works!
        </a>
      </section>

      <section>
        <h3>Reporting Issues/Feature Requests</h3>
        <p>
          Please report any known issues/bugs on our{' '}
          <a href="https://github.com/Breadkenty/Smash_Combos">
            Github repository
          </a>{' '}
          or on our <a href="https://discord.gg/VbnAwUg">Discord Server</a>.
        </p>
        <br />
        <p>
          For feature requests, you can tweet{' '}
          <a href="https://twitter.com/KentoKawakami/">@KentoKawakami</a> or
          request it in the #feature-requests channel in our
          <a href="https://discord.gg/VbnAwUg"> Discord Server</a>.
        </p>
      </section>

      <section>
        <h3>Supporting the project</h3>
        <p>Coming soon...</p>
      </section>

      <section>
        <h3>Source Code</h3>
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
            <a href="https://www.ssbwiki.com/">Smash Wiki</a>
            <p>: Controller buttons</p>
          </li>
          <li>
            <a href="https://www.spriters-resource.com/">Spriters Resource</a>
            <p>: Character images</p>
          </li>
          <li>
            <a href="https://ultimateframedata.com/">Ultimate Frame Data</a>
            <p>: Was really inspired by MetalMusicMan's work!</p>
          </li>
          <li>
            <a href="https://twitter.com/Samsora_">eU Samsora</a>
            <p>: Videos for examples, and bc I'm also a Peach main</p>
          </li>
          <li>
            <a href="https://suncoast.io/">Suncoast Developers Guild</a>
            <p>
              : Where I learned to make this app in 3 months from no experience
              whatsoever
            </p>
          </li>
        </ul>
      </section>
      <section>
        <h3>Contributors:</h3>
        <ul className="contributors">
          {contributors.map(contributor => (
            <li>
              <img src={contributor.avatar_url} />
              <a href={contributor.url}>
                <h4>{contributor.login}</h4>
              </a>
            </li>
          ))}
        </ul>
      </section>
    </div>
  )
}
