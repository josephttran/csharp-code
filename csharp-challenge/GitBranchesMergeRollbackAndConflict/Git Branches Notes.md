## Git Branches Challenge Note


Create new local git repository

`git init`

Add all to staging area to be commited

`git add .`

Check what is in staging area

`git status`

Commit the file

`git commit -m "commit message"

Create new branch and switch to it

`git checkout -b NewBranchName`

Merge branch with master branch

`git merge master`

Merge branch onto master

`git checkout master`

`git merge NewBranchName`

View commit history

`git log`

Roll back to previous commit rewrite history

`git reset --hard 54312`

--hard (means staged snapshot and the working directory are both updated to match the specified commit)

54312 (the previous commit SHA checksum)

**Reset** alter the existing commit history

**Revert** undo a commit by creating a new commit