import Socials from './components/Socials'
import Files from './components/Files'

function App() {
  return (
    <>
      <div className="flex-parent">
        <div className="left-column">
          <br />
          <p>Mitchell Fenner - DevOps Engineer</p>
		  <br />
          <Socials />
		  <br />
		  <br />
          <Files />
        </div>
      </div>
    </>
  )
}

export default App
