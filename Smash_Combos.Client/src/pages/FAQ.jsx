import React from 'react'

export function FAQ() {
  return (
    <div className="FAQ">
      <section>
        <h1>Frequently Asked Questions</h1>
        <hr />

        <div className="question">
          <h2>How Do I make a combo?</h2>
          <p>
            Sign up/login to your account, then on the side nav bar navigate to
            Submit a combo
          </p>
        </div>

        <div className="question">
          <h2>How can I make my combos when it’s lacking a certain feature?</h2>
          <p>
            Be as elaborate as you can with the inputs. You have the notes
            section to make additional remarks. Making character-specific inputs
            is very low on our priority list. If you have suggestions on
            something that is universal, leave a suggestion in the
            #feature-request channel on our{' '}
            <a href="https://discord.gg/VbnAwUg">Discord server</a>. Keep in
            mind you have to be an active member to leave requests.
          </p>
        </div>

        <div className="question">
          <h2>Why is my video invalid?</h2>
          <p>
            Our video validation form has keyword filters to prevent non-smash
            related posts. Generally speaking, a video should include some
            keywords relating to Super Smash Bros Ultimate or the name of the
            character you have selected.
          </p>
        </div>
        <div className="question">
          <h2>What’s a conditional?</h2>
          <p>
            Conditionals are used to write combos as if they are a
            sentence. They are used between inputs to indicate what comes next.
            Refer to our tutorial for further explanation
          </p>
        </div>
        <div className="question">
          <h2>Do I need to use my own videos?</h2>
          <p>
            No, you ARE allowed to use videos that are not yours. It would be
            nice to credit the user who discovered the combo in the notes
            section, but the video you use will link back to the original
            poster’s video in the video player.
          </p>
        </div>
        <div className="question">
          <h2>Do you have a Discord server?</h2>
          <p>
            <a href="https://discord.gg/VbnAwUg">Yes, we do!</a>
          </p>
        </div>
        <div className="question">
          <h2>I’m a developer, how can I contribute?</h2>
          <p>
            Glad you asked! Smash Combos is an open-source project. Check out
            our{' '}
            <a href="https://github.com/Breadkenty/Smash_Combos">
              source code on GitHub
            </a>{' '}
            and make sure you read the{' '}
            <a href="https://github.com/Breadkenty/Smash_Combos/blob/develop/CONTRIBUTING.md">
              Contributing Guideline
            </a>
            . It’ll also help to join our{' '}
            <a href="https://discord.gg/VbnAwUg">Discord server</a> where
            developers have their own channel.
          </p>
        </div>
        <div className="question">
          <h2>How can I support the project?</h2>
          <p>
            Glad you asked! Smash Combos is a completely free site to use but
            there are some costs associated so anything helps. You can support
            the project by donating on our{' '}
            <a href="https://www.patreon.com/smash_combos">Patreon</a> or
            sharing combos with your friends and other people in the community
            :)
          </p>
        </div>
        <div className="question">
          <h2>Can I advertise or make any type of self-promotion?</h2>
          <p>
            We generally do not promote any kind of advertisement that will lead
            us to any type of monetary profit (we don’t want to get sued by
            Nintendo!). However, we are open to promoting other Smash resources
            such as Character Discords and would love to work out some type of
            community partnership. Please reach out to a mod/admin to get the
            conversation started.
          </p>
        </div>
        <div className="question">
          <h2>Can you add [Insert feature here] to the site?</h2>
          <p>
            Feedback and feature requests are great, as it always gives us
            something to work on and improve. However, we get an overwhelming
            amount of requests for improvements and feedback, and
            reading/implementing all of them would take a really long time. If
            you would like to request features, you need to have the
            @C..C..C..COMBO_MAKERS Role in our{' '}
            <a href="https://discord.gg/VbnAwUg">Discord server</a> where you
            will have access to the #feature-request channel. Based on
            demand/workload, we will use our best judgment on how to prioritize
            features.
          </p>
        </div>
        <div className="question">
          <h2>How can I report a bug?</h2>
          <p>
            Report all bugs on our #bugs channel in our{' '}
            <a href="https://discord.gg/VbnAwUg">Discord server</a> or submit an
            issue on our GitHub Repository
          </p>
        </div>
      </section>
    </div>
  )
}
