#!/bin/bash
sudo su - <<EOF
systemctl stop WorkerServiceDemo.service
systemctl disable WorkerServiceDemo.service
rm /etc/systemd/system/WorkerServiceDemo.service
systemctl daemon-reload

echo 'uninstallserver success'
EOF
