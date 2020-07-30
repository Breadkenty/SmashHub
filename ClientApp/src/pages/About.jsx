import React, { useState } from 'react'

import video from '../graphics/demo/video.gif'
import combo from '../graphics/demo/combo.gif'
import smashComboInterface from '../graphics/demo/interface.gif'

export function About() {
  return (
    <div className="about">
      <section className="about-section">
        <header>
          <h1>Create your own combo inputs.</h1>
          <p>
            With Smash Combos, you are able to create customized inputs of any
            of your favorite characters
          </p>
        </header>
        <div
          className="gif-container"
          style={{ backgroundImage: `url(${combo})` }}
        ></div>
      </section>

      <section className="about-section">
        <header>
          <h1>Visualize combos through a video.</h1>
          <p>
            Smash combos will allow you highlight combos in a video by finding
            sections of a video to repeat.
          </p>
        </header>
        <div
          className="gif-container"
          style={{ backgroundImage: `url(${video})` }}
        ></div>
      </section>

      <section className="about-section">
        <header>
          <h1>Explore combos posted by other users.</h1>
          <p>
            Learning a character and its combo has never been easier. Check out
            combos that users have uploaded and share with friends.
          </p>
        </header>
        <div
          className="gif-container"
          style={{ backgroundImage: `url(${smashComboInterface})` }}
        ></div>
      </section>
    </div>
  )
}
