#! /bin/bash

echo "********** DEPLOYING PERSISTENCE STACK **********"
pushd explorer/stacks/persistance/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING APPLICATION STACK **********"
pushd explorer/stacks/application/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING PUBLIC STACK **********"
pushd explorer/stacks/public/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit

echo "********** DEPLOYING OPERATIONS STACK **********"
pushd operations/scripts/ > /dev/null || exit
./deploy.sh
popd > /dev/null || exit
