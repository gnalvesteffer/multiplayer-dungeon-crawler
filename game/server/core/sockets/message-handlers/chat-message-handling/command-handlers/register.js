const {AccountService, maxUsernameLength, maxPasswordLength} = require('../../../../game/account/account-service');

module.exports = ({message, sendChatMessage, socket, redisClient}) => {
  if (message.length !== 2) {
    sendChatMessage('[SYSTEM]', 'Invalid usage. Type "::register USERNAME PASSWORD"');
    return;
  }
  sendChatMessage('[SYSTEM]', 'Attempting to register...');
  const [username, password] = message;
  if (username.length > maxUsernameLength) {
    sendChatMessage('[SYSTEM]', `Username must not exceed ${maxUsernameLength} characters`);
    return;
  }
  if (password.length > maxPasswordLength) {
    sendChatMessage('[SYSTEM]', `Password must not exceed ${maxPasswordLength} characters`);
    return;
  }
  new AccountService({socket, redisClient}).register(
    username,
    password,
    () => {
      sendChatMessage('[SYSTEM]', 'Account created!');
    },
    (errorMessage) => {
      sendChatMessage('[SYSTEM]', `Registration failed: ${errorMessage}.`);
    }
  );
};