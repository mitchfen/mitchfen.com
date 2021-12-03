import { SiOrcid, SiGithub, SiLinkedin, SiDocker } from 'react-icons/si'
import { MdEmail } from 'react-icons/md'

const github = "https://github.com/mitchfen"
const linkedin = "https://linkedin.com/in/mitchfen"
const email = "mailto:mitchfen@mitchfen.xyz"
const orchid = "https://orcid.org/0000-0002-9684-0447"
const dockerhub = "https://hub.docker.com/u/mitchfen"

const Socials = () => {
  return (
    <>
      <a
        href={github}
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiGithub className="social" size={40} />
      </a>{' '}
      <a
        href={linkedin}
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiLinkedin className="social" size={40} />
      </a>{' '}
      <a href={email}>
        <MdEmail className="social" size={40} />
      </a>{' '}
      <a
        href={orchid}
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiOrcid className="social" size={40} />
      </a>{' '}
       <a
        href={dockerhub}
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiDocker className="social" size={40} />
      </a>{' '}
    </>
  )
}

export default Socials
