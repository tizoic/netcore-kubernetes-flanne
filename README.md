# netcore-kubernetes-flanne

# Pre Requisite
# Disable swap memory

$ sudo swapoff -a

$ sudo nano /etc/fstab (Comment swap line / reboot)

# Create image backend:1.0.0 docker
$ cd backend/src/
$ docker build -t backend:1.0.0 .

# Installing kubeadm, kubelet and kubectl
$ sudo apt-get update && sudo apt-get install -y apt-transport-https curl

$ curl -s https://packages.cloud.google.com/apt/doc/apt-key.gpg | sudo apt-key add -

$ cat <<EOF | sudo tee /etc/apt/sources.list.d/kubernetes.list
deb https://apt.kubernetes.io/ kubernetes-xenial main
EOF

$ sudo apt-get update

$ sudo apt-get install -y kubelet kubeadm kubectl

$ sudo apt-mark hold kubelet kubeadm kubectl

# Installing/Starting Flannel

$ sudo kubeadm init --pod-network-cidr=10.244.0.0/16

$ mkdir -p $HOME/.kube

$ sudo cp -f /etc/kubernetes/admin.conf $HOME/.kube/config

$ sudo chown $(id -u):$(id -g) $HOME/.kube/config

$ kubectl apply -f https://raw.githubusercontent.com/coreos/flannel/master/Documentation/kube-flannel.yml

$ kubectl taint nodes --all node-role.kubernetes.io/master-

# Create Namespace 'Develop'
$ kubectl apply -f ./devops/01-Namespace/ns.yaml

# Get Namespace
$ kubectl get ns

# Create Deployment
$ kubectl apply -f ./devops/02-Deployment/deployment.yaml -n develop

# Get Deployment
$ kubectl get deploy -n develop

# Create Services
$ kubectl apply -f ./devops/02-Services/services.yaml -n develop

# Get Services
$ kubectl get svc -n develop

# Get all
$ kubectl get all --all-namespaces

# Goto
http://localhost:30080/swagger
