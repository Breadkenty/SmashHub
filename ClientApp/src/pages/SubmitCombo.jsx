import React from 'react'

import { Basic } from '../components/combo-inputs/Basic'
import { Move } from '../components/combo-inputs/Move'
import { Flick } from '../components/combo-inputs/Flick'
import { Hop } from '../components/combo-inputs/Hop'
import { Conditional } from '../components/combo-inputs/Conditional'
import { Tilt } from '../components/combo-inputs/Tilt'
import { Aerial } from '../components/combo-inputs/Aerial'
import { Smash } from '../components/combo-inputs/Smash'
import { Special } from '../components/combo-inputs/Special'
import { Throw } from '../components/combo-inputs/Throw'

// Basic
import jabBasic from '../graphics/inputs/png/basic/jab-basic.png'
import grabBasic from '../graphics/inputs/png/basic/grab-basic.png'
import shieldBasic from '../graphics/inputs/png/basic/shield-basic.png'

// Move
import upMove from '../graphics/inputs/png/move/up-move.png'
import forwardMove from '../graphics/inputs/png/move/forward-move.png'
import downMove from '../graphics/inputs/png/move/down-move.png'
import backMove from '../graphics/inputs/png/move/back-move.png'

// Flick
import upFlick from '../graphics/inputs/png/flick/up-flick.png'
import forwardFlick from '../graphics/inputs/png/flick/forward-flick.png'
import downFlick from '../graphics/inputs/png/flick/down-flick.png'
import backFlick from '../graphics/inputs/png/flick/back-flick.png'

// Hop
import shortHop from '../graphics/inputs/png/hop/short-hop.png'
import mediumHop from '../graphics/inputs/png/hop/medium-hop.png'
import fullHop from '../graphics/inputs/png/hop/full-hop.png'

// Conditional
import andConditional from '../graphics/inputs/png/conditional/and-conditional.png'
import thenConditional from '../graphics/inputs/png/conditional/then-conditional.png'
import holdConditional from '../graphics/inputs/png/conditional/hold-conditional.png'
import releaseConditional from '../graphics/inputs/png/conditional/release-conditional.png'
import startRepeatConditional from '../graphics/inputs/png/conditional/startrepeat-conditional.png'
import endRepeatConditional from '../graphics/inputs/png/conditional/endrepeat-conditional.png'

// Tilt
import upTilt from '../graphics/inputs/png/tilt/up-tilt.png'
import forwardTilt from '../graphics/inputs/png/tilt/forward-tilt.png'
import downTilt from '../graphics/inputs/png/tilt/down-tilt.png'
import backTilt from '../graphics/inputs/png/tilt/back-tilt.png'

// Aerial
import upAerial from '../graphics/inputs/png/aerial/up-aerial.png'
import forwardAerial from '../graphics/inputs/png/aerial/forward-aerial.png'
import downAerial from '../graphics/inputs/png/aerial/down-aerial.png'
import backAerial from '../graphics/inputs/png/aerial/back-aerial.png'
import zAerial from '../graphics/inputs/png/aerial/z-aerial.png'
import neutralAerial from '../graphics/inputs/png/aerial/neutral-aerial.png'

// Smash
import upSmash from '../graphics/inputs/png/smash/up-smash.png'
import forwardSmash from '../graphics/inputs/png/smash/forward-smash.png'
import downSmash from '../graphics/inputs/png/smash/down-smash.png'
import backSmash from '../graphics/inputs/png/smash/back-smash.png'

// Special
import upSpecial from '../graphics/inputs/png/special/up-special.png'
import forwardSpecial from '../graphics/inputs/png/special/forward-special.png'
import downSpecial from '../graphics/inputs/png/special/down-special.png'
import backSpecial from '../graphics/inputs/png/special/back-special.png'
import neutralSpecial from '../graphics/inputs/png/special/neutral-special.png'

// Throw
import upThrow from '../graphics/inputs/png/throw/up-throw.png'
import forwardThrow from '../graphics/inputs/png/throw/forward-throw.png'
import downThrow from '../graphics/inputs/png/throw/down-throw.png'
import backThrow from '../graphics/inputs/png/throw/back-throw.png'

import peach from '../graphics/characters/Mario/Mario-5.png'

export function SubmitCombo() {
  return (
    <div className="submit-combo">
      <header>
        <h1>New combo</h1>
      </header>

      <section className="bg-grey">
        <form>
          <fieldset className="select-character">
            <label for="select-character">Choose a character</label>
            <div
              style={{
                backgroundImage: `url(${peach})`,
                backgroundPositionY: `30%`,
              }}
              className="character bg-black"
            >
              <select name="select-character">
                <option value="peach">Peach</option>
                <option value="bayonetta">Bayonetta</option>
                <option value="luigi">Luigi</option>
                <option value="minmin">Min Min</option>
                <option value="link">Link</option>
                <option value="wolf">Wolf</option>
              </select>
            </div>
          </fieldset>

          <fieldset className="title">
            <label for="title">Title</label>
            <input
              className="bg-yellow"
              id="title"
              type="text"
              placeholder="eg. Down-throw bair"
            />
          </fieldset>

          <fieldset className="video">
            <label for="video-id">Youtube video ID</label>
            <input
              className="bg-yellow"
              id="video-id"
              type="text"
              placeholder="eg. IE1lyGZgLOs"
            />
          </fieldset>

          <div className="duration ">
            <fieldset>
              <label for="video-start">Start time in video</label>
              <div className="bg-yellow">
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-start"
                  placeholder="00"
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-start"
                  placeholder="00"
                />
              </div>
            </fieldset>

            <fieldset>
              <label for="video-end">End time in video</label>
              <div className="bg-yellow">
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                />
                <span>:</span>
                <input
                  className="bg-yellow"
                  type="number"
                  max="60"
                  min="0"
                  id="video-end"
                  placeholder="00"
                />
              </div>
            </fieldset>
          </div>

          <fieldset className="difficulty">
            <label>Difficulty</label>
            <div>
              <button className="button bg-blue">Very Easy</button>
              <button className="button bg-green">Easy</button>
              <button className="button bg-yellow">Medium</button>
              <button className="button bg-pink">Hard</button>
              <button className="button bg-red">Very Hard</button>
            </div>
          </fieldset>

          <fieldset className="true-combo">
            <label>True Combo</label>
            <div>
              <button className="button bg-green">Yes</button>
              <button className="button bg-red">No</button>
            </div>
          </fieldset>

          <fieldset className="damage">
            <label>Damage</label>
            <div className="container bg-yellow">
              <input className="bg-yellow" type="number" placeholder="0" />
              <span className="bg-yellow">%</span>
            </div>
          </fieldset>

          <fieldset className="combo-input">
            <label>Combo input</label>

            <div className="combo-input-container bg-black">
              <div className="combo-inputs">
                <div
                  className="combo-input"
                  style={{
                    // backgroundColor: `red`,
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${forwardAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${backAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${zAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${neutralAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />

                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${upAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
                <div
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${downAerial})`,
                  }}
                />
              </div>
              <p>*Click this area to go back one input*</p>
            </div>
            <div className="input-categories">
              <button>Basic</button>
              <button>Move</button>
              <button>Flick</button>
              <button>Hop</button>
              <button>Cond.</button>
              <button>Tilt</button>
              <button>Aerial</button>
              <button>Smash</button>
              <button>Special</button>
              <button>Throw</button>
            </div>

            <div className="input-controller bg-black">
              {/* <Basic /> */}
              {/* <Move /> */}
              {/* <Flick /> */}
              {/* <Hop /> */}
              {/* <Conditional /> */}
              {/* <Tilt /> */}
              {/* <Aerial /> */}
              {/* <Smash /> */}
              {/* <Special /> */}
              <Throw />
            </div>
          </fieldset>

          <fieldset className="notes">
            <label for="notes">Notes</label>
            <div>
              <textarea placeholder="Additional notes" />
              <button type="submit" className="button bg-yellow black-text">
                Submit
              </button>
            </div>
          </fieldset>
        </form>
      </section>
    </div>
  )
}
