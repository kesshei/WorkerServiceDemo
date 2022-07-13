#!/bin/bash
sudo su - <<EOF
systemctl stop WorkerServiceDemo.service
systemctl disable WorkerServiceDemo.service
echo 'Server stop Success'
EOF
