# Deploy using ARM template
# Usage: ./deploy.sh <resource group name> <location> <template file> <parameters file>
# Example: ./deploy.sh BookshopServer westeurope azuredeploy.json azuredeploy.parameters.json

# Check for required parameters
if [ $# -lt 4 ]; then
    echo "Usage: ./deploy.sh <resource group name> <location> <template file> <parameters file>"
    exit 1
fi

# Set variables
RESOURCE_GROUP_NAME=$1
LOCATION=$2
TEMPLATE_FILE=$3
PARAMETERS_FILE=$4

# Create resource group
az group create --name $RESOURCE_GROUP_NAME --location $LOCATION

# Deploy template
az deployment group create --resource-group $RESOURCE_GROUP_NAME \
 --template-file $TEMPLATE_FILE \
 --parameters $PARAMETERS_FILE \
 --parameters name=$RESOURCE_GROUP_NAME serverFarmResourceGroup=$RESOURCE_GROUP_NAME 

echo "Deployment complete"
