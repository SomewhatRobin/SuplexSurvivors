#### MCS 1643 README file
# **Suplex Survivors**

#### Author: *Jacob Robinson & Carlota Zafra*

##### Modified: *2025-12-11*

<br>

#### Questions for projects: (remove this section for tutorial assignments)
**1. What are the controls to your game? How do we play?**   

> &nbsp;
><i>The game can be played with either a controller or on the keyboard.
WASD on keyboard/Left Stick on controller to move
Space Bar / A or B for every grab and/or throw.
The move that the player character uses depends on whether the attack button is pressed or held until a target time.
The move that will be used if the player releases the button is indicated in the top right corner of the screen.
</i>   
> &nbsp;
 


**2. What creative additions/enhancements did you make? How can we find them?**   

> &nbsp;
><i>After finding a bug where the player can become vulnerable during either Rubble Dump or (Bigby, p. 360),
 Jacob made the animation for both spells move the hurtbox above the enemies, making the player effectively invincible as long as
 they would be when the bug hadn't happened.
 
 There is background art, believe it or not, (hastily) drawn by Jacob. This was added to make it easier to tell where one is moving.</i>   
> &nbsp;
 


**3. Any assets used that you didn't create yourself?**   

> &nbsp;
><i>The background for the main menu was taken from ( https://discover.hubpages.com/religion-philosophy/Do-People-Burn-In-Hell-For-Eternity ), found in a google search.
The image for (Bigby, p. 360) was taken from dustloop ( https://www.dustloop.com/w/GGST/Potemkin#Potemkin_Buster )
The image for Rubble Dump was taken from the kirbyWiki ( https://wikirby.com/wiki/Suplex#Gallery , Ability star from Star Allies )
The title text was made from a mashup of the title screen art from Vampire Survivors (full link further down),
and the Suplex ability art from Kirby Super Star ( https://wikirby.com/wiki/Suplex#Gallery )
The sound effects were made from samples of the instruments in Kirby's Dream Land 3.
</i>   
> &nbsp;
 


**4. Did you receive help from anyone outside this class or from anyone in this class that is not in a group with you?**   

> &nbsp;
><i>Playtesting was done by:
Matthew Robinson
Zachary Robinson
Rebecca Robinson
Ross Lewerenz
...and more</i>   
> &nbsp;
 


**5. Did you get help from any AI Code Assistants?**   

> &nbsp;
><i>(Including things like Chat-GPT, Copilot, etc. Tell us which .cs file to look in for the citation and describe what you learned)</i>   
> &nbsp;
 


**6. Did you get help from any online websites, videos, or tutorials?**   

> &nbsp;
><i>Unity Help Forums

Youtube Tutorials for:
Billboarding (https://www.youtube.com/watch?v=FjJJ_I9zqJo)
Unity Pausing (https://www.youtube.com/watch?v=UGh4exLCFRg)
Menus with Controller Input (https://www.youtube.com/watch?v=SXBgBmUcTe0)
Scripting with Animator (https://www.youtube.com/watch?v=I_ilRHeHvIs)
How to use Animation Events (https://www.youtube.com/watch?v=92P2Zz6K9vA)
Animation Position Issues Fix (https://www.youtube.com/watch?v=B0sZVuuZHeQ)

</i>   
> &nbsp;
 


**7. What trouble did you have with this project?**   

> &nbsp;
><i>Jacob had trouble getting the gameObjects to work in a way that made animating less tedious (The PlayerSprite was a separate object from other components, was the main object that got animated)
There were also issues with getting arm movement working for the "Launch Grab" spell, which can be seen at lower fps during gameplay. 
Additionally, the jump sound effect plays twice when using RD or PB.
Getting each grab to be functional without preventing further actions from the player was difficult.</i>   
> &nbsp;
 


**8. Is there anything else we should know?**   

> &nbsp;
>*I didn't get to add my dog's growling this time around, but I did get emotionally attached to this project. -Jacob*
> &nbsp;

---

# This starter is based on Jeremy Gibson Bond's MI 231 Starter, https://github.com/MSU-mi231/Unity-3D-Template-2022.3
# (which in turn incorporates some collaborative work and suggestions from me)

# Default GitLab README Content is Below
To make it easy for you to get started with GitLab, here's a list of recommended next steps.

Already a pro? Just edit this README.md and make it your own. Want to make it easy? [Use the template at the bottom](#editing-this-readme)!

## Add your files

- [ ] [Create](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#create-a-file) or [upload](https://docs.gitlab.com/ee/user/project/repository/web_editor.html#upload-a-file) files
- [ ] [Add files using the command line](https://docs.gitlab.com/ee/gitlab-basics/add-file.html#add-a-file-using-the-command-line) or push an existing Git repository with the following command:

```
cd existing_repo
git remote add origin https://gitlab.msu.edu/mi231-f22/templates/unity-project-template.git
git branch -M main
git push -uf origin main
```

## Integrate with your tools

- [ ] [Set up project integrations](https://gitlab.msu.edu/mi231-f22/templates/unity-project-template/-/settings/integrations)

## Collaborate with your team

- [ ] [Invite team members and collaborators](https://docs.gitlab.com/ee/user/project/members/)
- [ ] [Create a new merge request](https://docs.gitlab.com/ee/user/project/merge_requests/creating_merge_requests.html)
- [ ] [Automatically close issues from merge requests](https://docs.gitlab.com/ee/user/project/issues/managing_issues.html#closing-issues-automatically)
- [ ] [Enable merge request approvals](https://docs.gitlab.com/ee/user/project/merge_requests/approvals/)
- [ ] [Automatically merge when pipeline succeeds](https://docs.gitlab.com/ee/user/project/merge_requests/merge_when_pipeline_succeeds.html)

## Test and Deploy

Use the built-in continuous integration in GitLab.

- [ ] [Get started with GitLab CI/CD](https://docs.gitlab.com/ee/ci/quick_start/index.html)
- [ ] [Analyze your code for known vulnerabilities with Static Application Security Testing(SAST)](https://docs.gitlab.com/ee/user/application_security/sast/)
- [ ] [Deploy to Kubernetes, Amazon EC2, or Amazon ECS using Auto Deploy](https://docs.gitlab.com/ee/topics/autodevops/requirements.html)
- [ ] [Use pull-based deployments for improved Kubernetes management](https://docs.gitlab.com/ee/user/clusters/agent/)
- [ ] [Set up protected environments](https://docs.gitlab.com/ee/ci/environments/protected_environments.html)

***

# Editing this README

When you're ready to make this README your own, just edit this file and use the handy template below (or feel free to structure it however you want - this is just a starting point!). Thank you to [makeareadme.com](https://www.makeareadme.com/) for this template.

## Suggestions for a good README
Every project is different, so consider which of these sections apply to yours. The sections used in the template are suggestions for most open source projects. Also keep in mind that while a README can be too long and detailed, too long is better than too short. If you think your README is too long, consider utilizing another form of documentation rather than cutting out information.

## Name
Choose a self-explaining name for your project.

## Description
Let people know what your project can do specifically. Provide context and add a link to any reference visitors might be unfamiliar with. A list of Features or a Background subsection can also be added here. If there are alternatives to your project, this is a good place to list differentiating factors.

## Badges
On some READMEs, you may see small images that convey metadata, such as whether or not all the tests are passing for the project. You can use Shields to add some to your README. Many services also have instructions for adding a badge.

## Visuals
Depending on what you are making, it can be a good idea to include screenshots or even a video (you'll frequently see GIFs rather than actual videos). Tools like ttygif can help, but check out Asciinema for a more sophisticated method.

## Installation
Within a particular ecosystem, there may be a common way of installing things, such as using Yarn, NuGet, or Homebrew. However, consider the possibility that whoever is reading your README is a novice and would like more guidance. Listing specific steps helps remove ambiguity and gets people to using your project as quickly as possible. If it only runs in a specific context like a particular programming language version or operating system or has dependencies that have to be installed manually, also add a Requirements subsection.

## Usage
Use examples liberally, and show the expected output if you can. It's helpful to have inline the smallest example of usage that you can demonstrate, while providing links to more sophisticated examples if they are too long to reasonably include in the README.

## Support
Tell people where they can go to for help. It can be any combination of an issue tracker, a chat room, an email address, etc.

## Roadmap
If you have ideas for releases in the future, it is a good idea to list them in the README.

## Contributing
State if you are open to contributions and what your requirements are for accepting them.

For people who want to make changes to your project, it's helpful to have some documentation on how to get started. Perhaps there is a script that they should run or some environment variables that they need to set. Make these steps explicit. These instructions could also be useful to your future self.

You can also document commands to lint the code or run tests. These steps help to ensure high code quality and reduce the likelihood that the changes inadvertently break something. Having instructions for running tests is especially helpful if it requires external setup, such as starting a Selenium server for testing in a browser.

## Authors and acknowledgment
Show your appreciation to those who have contributed to the project.

## License
For open source projects, say how it is licensed.

## Project status
If you have run out of energy or time for your project, put a note at the top of the README saying that development has slowed down or stopped completely. Someone may choose to fork your project or volunteer to step in as a maintainer or owner, allowing your project to keep going. You can also make an explicit request for maintainers.