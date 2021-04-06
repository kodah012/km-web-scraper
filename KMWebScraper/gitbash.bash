#!/bin/bash

# Var that stores our current branch name
branch=`git branch --show-current`

# Var that stores whether or not a remote branch is present
isRemoteBranchPresent=$(git ls-remote --heads origin ${branch} | wc -l | sed 's/ //g')

#echo "Currently on branch -> $branch"
#echo "Remote Branch Present -> $isRemoteBranchPresent"

function promptCorrectCommitFiles()
{
	local files=`git diff --diff-filter=A --name-only HEAD`
	read -p $"Are these files correct?" $'\n' "$files" $'\n' answer
}


function commit
{
	local a=1	
}


function push()
{
	if [ isRemoteBranchPresent ] ; then
		echo "found"
		# git push
	else
		echo "not found"
		#git push --set-upstream origin $branch
	fi
}

promptCorrectCommitFiles

#if  [[ isRemoteBranchPresent == 1 ]] ; then
#	echo "Remote branch present for branch: $branch
#fi

exit 0
