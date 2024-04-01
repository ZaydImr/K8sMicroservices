kind create cluster --name nginx-ingress --image kindest/node:v1.27.1

helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx

$CHART_VERSION="4.10.0"
$APP_VERSION="1.10.0"

helm template ingress-nginx ingress-nginx --repo https://kubernetes.github.io/ingress-nginx --version ${CHART_VERSION} --namespace ingress-nginx > .\manifests\nginx-ingress.${APP_VERSION}.yaml

# Deploy the Ingress controller
kubectl create namespace ingress-nginx
kubectl apply -f .\manifests\nginx-ingress.${APP_VERSION}.yaml

kubectl -n ingress-nginx get pods
kubectl -n ingress-nginx get svc

kubectl -n ingress-nginx port-forward svc/ingress-nginx-controller 443

kubectl -n ingress-nginx logs -l app.kubernetes.io/instance=ingress-nginx
kubectl logs -l app=....