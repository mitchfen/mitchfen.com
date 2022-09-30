curl \
-H "Accept: application/vnd.github.v3+json" \
-H "Authorization: token $token" \
https://api.github.com/user/packages/container/mitchfen.xyz/versions

curl \
-X DELETE \
-H "Accept: application/vnd.github.v3+json" \
-H "Authorization: token $token" \
https://api.github.com/user/packages/container/mitchfen.xyz/versions/19289773
