import { SiOrcid, SiGithub, SiLinkedin } from "react-icons/si";
import { MdEmail } from "react-icons/md";

const Socials = () => {
  return (
    <>
      <a
        href="https://github.com/mitchfen"
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiGithub className="social" size={40} />
      </a>{" "}
      <a
        href="https://www.linkedin.com/in/mitchfen/"
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiLinkedin className="social" size={40} />
      </a>{" "}
      <a href="mailto:mitchfen@mitchfen.xyz">
        <MdEmail className="social" size={40} />
      </a>{" "}
      <a
        href="https://orcid.org/0000-0002-9684-0447"
        rel="noopener noreferrer"
        target="_blank"
      >
        <SiOrcid className="social" size={40} />
      </a>{" "}
    </>
  );
};

export default Socials;
