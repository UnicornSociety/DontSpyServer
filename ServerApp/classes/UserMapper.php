<?php

class UserMapper extends Mapper
{
    public function getUser()
    {
        $stmt = $this->db->query("SELECT * FROM User");
        $results = [];
        while ($row = $stmt->fetch()) {
            $results[] = new UserEntity($row);
        }
        return $results;
    }

    public function getUserByUsername($user_username)
    {
        $stmt = $this->db->prepare("SELECT * FROM user WHERE username = :user_username");
        $result = $stmt->execute(["user_username" => $user_username]);
        if ($result) {
            return new UserEntity($stmt->fetch());
        }
    }

    public function save(UserEntity $user)
    {
        $stmt = $this->db->prepare("INSERT INTO user(id, username) VALUES (:id, :username)");
        $result = $stmt->execute([
            "id" => $user->getId(),
            "username" => $user->getUsername(),
        ]);
        if (!$result) {
            throw new Exception("Could not save record");
        }
    }
}
