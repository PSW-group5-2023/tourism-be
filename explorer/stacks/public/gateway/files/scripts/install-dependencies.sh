#!/bin/ash

set -e

apk --update --no-cache add curl tar gettext

FRONTEND_APP_SRC_URL=$1
GITHUB_TOKEN=$2

curl -L -o app.tar.gz -H "Authorization: token $GITHUB_TOKEN" "${FRONTEND_APP_SRC_URL}"
tar -xzvf app.tar.gz -C .
mv "$(find . -maxdepth 2 -type d -name 'Explorer')" app

cd app && npm install