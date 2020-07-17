import React from 'react'

import './custom.scss'
import './typeface.css'
import { TopNav } from './components/TopNav'

import { LandingPage } from './LandingPage'
import { SignUp } from './SignUp'
import { LogIn } from './LogIn'

import { CharacterSelect } from './CharacterSelect'
import peach from './graphics/characters/Peach/Peach-5.png'
import input from './graphics/inputs/png/aerial/back-aerial.png'

export function App() {
  return (
    <>
      <TopNav />
      {/* <LandingPage /> */}
      {/* <SignUp /> */}
      {/* <LogIn /> */}
      {/* <CharacterSelect /> */}
      <div className="character-combos header-space ">
        <header
          className="character-header-large"
          style={{
            backgroundImage: `url(${peach})`,
          }}
        >
          <h1>Peach</h1>
        </header>
        <div className="search-bar bg-lightblack">
          <input className="bg-yellow" type="text" placeholder="Search" />
          <div>
            <button className="bg-red button white-text">Popular</button>
            <button className="bg-red button white-text">Newest</button>
          </div>
        </div>
        <section>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
          <div className="character-combos-combo">
            <div className="vote-container bg-yellow">
              <div className="vote">
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowUpLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 26h32L18 10 2 26z"></path>
                </svg>
                <h3 className="black-text">42</h3>
                <svg
                  aria-hidden="true"
                  className="m0 svg-icon iconArrowDownLg"
                  width="36"
                  height="36"
                  viewBox="0 0 36 36"
                >
                  <path d="M2 10h32L18 26 2 10z"></path>
                </svg>
              </div>
            </div>
            <div className="character-combos-combo-information">
              <header>
                <h3>Down-tilt Ground Float Nair</h3>
                <button className="bg-pink button-small text-white small-text">
                  Hard
                </button>
              </header>
              <div className="combo-inputs">
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
                <button
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${input})`,
                  }}
                />
              </div>
              <footer>
                <p className="white-text">Posted by Breadkenty 2 hours ago</p>
              </footer>
            </div>
          </div>
        </section>
      </div>
    </>
  )
}
