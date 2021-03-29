# Security Policy
At DerangedSenators, we take the security of our products and services seriously and this applies to all of our public and private GitHub repositories.

If you believe that you may have uncovered a vulnerability in any of our repositories, please report it directly to us.
## Supported Versions

Cops And Robbers is still in its early release stage and as such, only the **latest** version will be supported at this time.
This will allow us to ensure a level playing field for all users

| Version | Supported          |
| ------- | ------------------ |
| 3.0.x   | :heavy_check_mark: |
| 2.x.x   | :x:                |
| 1.x.x   | :x:                |

## Reporting a Vulnerability
**Please do not report vulnerabilities through the public Issue/Discussion pages**

Instead, please contact us directly [here](https://www.copsandrobbers.co.uk/security/cvd)

Please include, in a zip file the requested information listed below (as much as you can provide) to help us better understand the nature and scope of the possible issue:

* Type of issue (e.g. buffer overflow, SQL injection, cross-site scripting, etc.)
* Full paths of source file(s) related to the manifestation of the issue
* The location of the affected source code (tag/branch/commit or direct URL)
* Any special configuration required to reproduce the issue
* Step-by-step instructions to reproduce the issue
* Proof-of-concept or exploit code (if possible)
* Impact of the issue, including how an attacker might exploit the issue

This information will help us triage your report more quickly.
Additionally, please encrypt the zip file using our PGP key; this can be downloaded from our [PGP Key Page](https://www.copsandrobbers.co.uk/security/pgp)
### Submitting Patches with vulnerability
We would appreciate patches submitted with the vulnerability report as it would help us pushing a fix sooner. To submit a patch, make a local commit(s) and then create patch files to include in the report. The command for creating patches is:
```
$ git format-patch <branch> <options> 
$ git format-patch -1 <commit_sha> # Cherrypick patches
```

## Policy
DerangedSenators follows the principle of [Coordinated Vulnerability Disclosure](https://apps.dtic.mil/sti/pdfs/AD1046659.pdf) (CVD)
