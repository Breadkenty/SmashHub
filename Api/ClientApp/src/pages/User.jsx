import React, { useState } from 'react'
import { Link } from 'react-router-dom'

import { allComboInputs } from '../components/combo-inputs/allComboInputs'
import { allCharacterCloseUp } from '../components/allCharacterCloseUp'
import { returnDifficulty } from '../components/returnDifficulty'

export function User() {
  const comboInputs =
    'upTilt upTilt upTilt upTilt upTilt upTilt upTilt upTilt upTilt upTilt'

  const [toggleReportDropDown, setToggleReportDropDown] = useState(false)
  const [toggleInfractionDropDown, setToggleInfractionDropDown] = useState(
    false
  )

  return (
    <div className="user">
      <header>
        <h1>Breadkenty</h1>
      </header>

      <section className="user-details">
        <header>
          <div>
            <h3>Reports: </h3>
            <h3 className="points">5</h3>
            <button className="button">Warn</button>
            <button className="button ban">Ban</button>
          </div>
          <button
            onClick={() => {
              if (!toggleReportDropDown) {
                setToggleReportDropDown(true)
              } else {
                setToggleReportDropDown(false)
              }
            }}
          >
            <svg
              viewBox="0 0 81 45"
              style={
                toggleReportDropDown ? { transform: 'rotate(360deg)' } : null
              }
            >
              <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
            </svg>
          </button>
        </header>

        <div
          className="drop-down"
          style={
            toggleReportDropDown ? { display: 'block' } : { display: 'none' }
          }
        >
          <form className="infraction-form">
            <div>
              <button className="button">Spam/Abuse</button>
              <button className="button">Inappropriate</button>
              <button className="button">Harassment</button>
            </div>
            <textarea placeholder="reason" />
            <button className="button" type="submit">
              Submit
            </button>
          </form>

          <div className="reports-header">
            <h5>Type</h5>
            <h5>Reported Content</h5>
            <h5>Comments</h5>
            <h5>Reported By</h5>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
          <div className="reports-row">
            <p>Spam</p>
            <Link to="#">Down tilt ground float nair</Link>
            <p>This is inappropriate, please remove</p>
            <Link to="#">Sleeping-dev</Link>
            <p className="report-date">08/21/20</p>
          </div>
        </div>
      </section>

      <section className="user-details">
        <header>
          <div>
            <h3>Infractions:</h3>
            <h3 className="points">3</h3>
          </div>
          <button
            onClick={() => {
              if (!toggleInfractionDropDown) {
                setToggleInfractionDropDown(true)
              } else {
                setToggleInfractionDropDown(false)
              }
            }}
          >
            <svg
              viewBox="0 0 81 45"
              style={
                toggleInfractionDropDown
                  ? { transform: 'rotate(360deg)' }
                  : null
              }
            >
              <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
            </svg>
          </button>
        </header>

        <div
          className="drop-down"
          style={
            toggleInfractionDropDown
              ? { display: 'block' }
              : { display: 'none' }
          }
        >
          <div className="reports-header">
            <h5>Points</h5>
            <h5>Comment</h5>
            <h5>Moderator</h5>
            <h5>Date</h5>
          </div>
          <div className="reports-row">
            <p className="points">2</p>
            <p>Infracted for spamming</p>
            <Link to="#">Sleeping-dev</Link>
            <p>08/21/20</p>
          </div>
          <div className="reports-row">
            <p className="points">2</p>
            <p>Infracted for spamming</p>
            <Link to="#">Sleeping-dev</Link>
            <p>08/21/20</p>
          </div>
          <div className="reports-row">
            <p className="points">2</p>
            <p>Infracted for spamming</p>
            <Link to="#">Sleeping-dev</Link>
            <p>08/21/20</p>
          </div>
          <div className="reports-row">
            <p className="points">2</p>
            <p>Infracted for spamming</p>
            <Link to="#">Sleeping-dev</Link>
            <p>08/21/20</p>
          </div>
        </div>
      </section>

      <section className="combos">
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
        <div className="combo">
          <div className="vote">
            <button className="button-blank">
              <svg viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
            <h3 className="black-text">21</h3>
            <button className="button-blank">
              <svg className="down-vote" viewBox="0 0 81 45">
                <path d="M40.55 3.003L3.015 41.985l19.406.044h.007l18.119-18.818 18.127 18.818h19.357L40.55 3.003z"></path>
              </svg>
            </button>
          </div>
          <div className="detail">
            <header>
              <div>
                <Link to={`/character/Peach`}>
                  <img
                    src={allCharacterCloseUp['Peach']}
                    alt={`Peach's portrait`}
                  />
                </Link>
                <Link to={`/character/Mario/1`}>
                  <h3>Some Cool Mario Combo</h3>
                </Link>
              </div>
              {returnDifficulty('hard ')}
            </header>

            <div className="combo-inputs">
              {comboInputs.split(' ').map((input, index) => (
                <div
                  key={index}
                  className="combo-input"
                  style={{
                    backgroundImage: `url(${allComboInputs[input]})`,
                  }}
                ></div>
              ))}
            </div>

            <footer>
              <h5 className="white-text">Posted 2 days ago</h5>
            </footer>
          </div>
        </div>
      </section>
    </div>
  )
}
