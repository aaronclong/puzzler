#!/bin/bash
FILE=./.env
migration_path=./puzzle/src/Puzzle
if [ ! -e "$FILE" ]; then
  echo "Setup your .env file"
else 
  cat $FILE | while read line
  do
    export $line
  done
  cd $migration_path
  pwd
  dotnet ef database update
fi
