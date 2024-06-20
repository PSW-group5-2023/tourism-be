#! /bin/bash

echo "********** DESTROYING OPERATIONS STACK **********"
./operations/scripts/destroy.sh

echo "********** DESTROYING PUBLIC STACK **********"
./explorer/stacks/public/scripts/destroy.sh

echo "********** DESTROYING APPLICATION STACK **********"
./explorer/stacks/application/scripts/destroy.sh

echo "********** DESTROYING PERSISTENCE STACK **********"
./explorer/stacks/persistance/scripts/destroy.sh

