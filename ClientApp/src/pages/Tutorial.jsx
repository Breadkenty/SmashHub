import React, { useState } from 'react'

import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import video from '../graphics/demo/video.gif'
import combo from '../graphics/demo/combo.gif'
import smashComboInterface from '../graphics/demo/interface.gif'

export function Tutorial() {
  return (
    <div className="tutorial">
      <h1>How to build a combo:</h1>

      <p>
        <strong>Conditionals</strong> are used to write these combos as if they
        are a sentence. Here are some definitions and examples:
      </p>

      <hr />

      <section>
        <div className="header-container">
          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div className="description">
              <h3>And</h3>
              <p> Combines two inputs as one input</p>
            </div>
          </div>
        </div>
        <h4>Examples:</h4>

        <div className="input-example-container">
          <h4>Full hop forward</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['fullHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
          </div>
        </div>

        <div className="input-example-container">
          <h4>Full hop forward</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['fullHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Full hop forward</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['fullHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
          </div>{' '}
        </div>
      </section>

      <section>
        <div className="header-container">
          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div className="description">
              <h3>Then</h3>
              <p> Proceeds to the next set of inputs</p>
            </div>
          </div>
        </div>

        <h4>Examples:</h4>
        <div className="input-example-container">
          <h4>Jab > jab > jab</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['jabBasic']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['jabBasic']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['jabBasic']})`,
              }}
            />
          </div>
        </div>

        <div className="input-example-container">
          <h4>Down tilt > up smash</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downTilt']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['upSmash']})`,
              }}
            />
          </div>
        </div>

        <div className="input-example-container">
          <h4>Down throw bair</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downThrow']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['shortHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['backAerial']})`,
              }}
            />
          </div>{' '}
        </div>
      </section>

      <section>
        <div className="header-container">
          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div className="description">
              <h3>Hold</h3>
              <p>Indicates the following input to be held</p>
            </div>
          </div>

          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />
            <div className="description">
              <h3>Release</h3>
              <p> Indicates the held button to be released</p>
            </div>
          </div>
        </div>

        <h4>Examples:</h4>
        <div className="input-example-container">
          <h4>Dash forward</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
          </div>
        </div>

        <div className="input-example-container">
          <h4>Crouch</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downMove']})`,
              }}
            />
          </div>
        </div>

        <div className="input-example-container">
          <h4>Up B out of shield</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['shieldBasic']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['upSpecial']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Ground float nair</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downMove']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['fullHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['neutralAerial']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Charged forward smash</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardSmash']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Charged forward special</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardSpecial']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />
          </div>{' '}
        </div>
      </section>

      <section>
        <div className="header-container">
          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div className="description">
              <h3>Start Repeat</h3>
              <p>
                Sets the beginning of the set of inputs that will be repeated
              </p>
            </div>
          </div>

          <div className="header">
            <div
              className="input-header"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />
            <div className="description">
              <h3>End Repeat</h3>
              <p>
                {' '}
                Indicates the end of the repeat; can be used to tell the amount
                of repeat times
              </p>
            </div>
          </div>
        </div>

        <h4>Examples:</h4>
        <div className="input-example-container">
          <h4>Up tilt x3</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['startRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['upTilt']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Ground float nair x3</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['startRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downMove']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['andConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['holdConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['fullHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['releaseConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['neutralAerial']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['forwardMove']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />{' '}
          </div>
        </div>

        <div className="input-example-container">
          <h4>Short hop fast fall nair x3</h4>
          <div className="inputs">
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['startRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['shortHop']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['downFlick']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['thenConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['neutralAerial']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />
            <div
              className="input-example"
              style={{
                backgroundImage: `url(${allComboInputs['endRepeatConditional']})`,
              }}
            />{' '}
          </div>
        </div>
      </section>

      <hr />
      <hr />
      <hr />
    </div>
  )
}
