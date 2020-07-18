import React from 'react'
import { Route, Switch } from 'react-router'

import './custom.scss'
import './typeface.css'

import { TopNav } from './components/TopNav'

import { LandingPage } from './LandingPage'

import { SignUp } from './SignUp'
import { LogIn } from './LogIn'

import { Character } from './Character'
import { Characters } from './Characters'

import { CharacterCombo } from './CharacterCombo'

import { SubmitCombo } from './SubmitCombo'

export function App() {
  return (
    <>
      <TopNav />
      <Switch>
        <Route exact path="/signup">
          <SignUp />
        </Route>
        <Route exact path="/login">
          <LogIn />
        </Route>
        <Route exact path="/">
          <LandingPage />
        </Route>
        <Route exact path="/characters">
          <Characters />
        </Route>
        <Route exact path="/characters/peach">
          <Character />
        </Route>
        <Route exact path="/characters/peach/2">
          <CharacterCombo />
        </Route>
        <Route exact path="/submit">
          <SubmitCombo />
        </Route>
      </Switch>
    </>
  )
}
