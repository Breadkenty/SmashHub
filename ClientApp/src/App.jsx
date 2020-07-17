import React from 'react'

import './custom.scss'
import './typeface.css'
import { TopNav } from './components/TopNav'

import { LandingPage } from './LandingPage'
import { SignUp } from './SignUp'

import { CharacterSelect } from './CharacterSelect'

export function App() {
  return (
    <>
      <TopNav />
      {/* <LandingPage /> */}
      {/* <SignUp /> */}
      {/* <LogIn /> */}
      <CharacterSelect />
    </>
  )
}
