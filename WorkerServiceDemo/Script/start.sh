#!/bin/bash
sudo su - <<EOF
systemctl daemon-reload
systemctl start WorkerServiceDemo.service
systemctl enable WorkerServiceDemo.service
echo 'Server start Success'
EOF
