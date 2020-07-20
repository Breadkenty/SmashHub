import React, { useState } from 'react'
import { Route, Switch } from 'react-router'

import './style/main.scss'

import { TopNav } from './components/TopNav'

import { LandingPage } from './pages/LandingPage'

import { SignUp } from './pages/SignUp'
import { LogIn } from './pages/LogIn'

import { Character } from './pages/Character'
import { Characters } from './pages/Characters'

import { CharacterCombo } from './pages/CharacterCombo'

import { SubmitCombo } from './pages/SubmitCombo'

import { SideNav } from './components/SideNav'

export function App() {
  const [sideNavDisplay, setSideNavDisplay] = useState(false)

  const handleSideBar = () => {
    if (sideNavDisplay) {
      setSideNavDisplay(false)
    } else {
      setSideNavDisplay(true)
    }
  }

  return (
    <>
      <SideNav handleSideBar={handleSideBar} sideNavDisplay={sideNavDisplay} />
      <div className={sideNavDisplay ? 'blur' : 'none'}>
        <TopNav handleSideBar={handleSideBar} />
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
      </div>
    </>
  )
}
